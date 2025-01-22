using System.Text;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Business;

public class SoapToRestMiddleware
{
    private readonly RequestDelegate _next;

    public SoapToRestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.ContentType == "text/xml" || context.Request.ContentType == "application/soap+xml")
        {
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
            var soapContent = await reader.ReadToEndAsync();

            var soapEndpoint = ParseSoapRequest(soapContent);

            var jsonResponse = await CallRestApi(soapEndpoint);

            var xmlContent = ConvertJsonToXml(jsonResponse);

            // XML'i SOAP formatına sar
            var soapResponse = WrapInSoapEnvelope(xmlContent);

            // Cevabı istemciye döndür
            context.Response.ContentType = "text/xml";
            await context.Response.WriteAsync(soapResponse);
            return;
        }

        // Diğer istekler için bir sonraki middleware'e geç
        await _next(context);
    }

    private string ParseSoapRequest(string soapRequestXml)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(soapRequestXml);
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
        nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
        XmlNode bodyNode = xmlDoc.SelectSingleNode("//soap:Body", nsmgr);
        var endpoint = bodyNode.ChildNodes[0]?.LocalName;

        if (endpoint != null)
        {
            //return bodyNode.InnerText;
            return endpoint;
        }

        throw new Exception("Invalid SOAP request");
    }

    private async Task<string> CallRestApi(string soapEndpoint)
    {
        using var httpClient = new HttpClient();
        string apiUrl = soapEndpoint switch
        {
            "GetAccounts" => "http://localhost:5154/api/Account/getall",
            _ => throw new Exception("Unknown endpoint")
        };
        var response = await httpClient.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    private string ConvertJsonToXml(string json)
    {
        JArray jsonArray = JArray.Parse(json);
        JObject wrappedObject = new JObject(new JProperty("Root", jsonArray));
        XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(wrappedObject.ToString(), "Root");
        return xmlDoc.OuterXml;
    }

    private string WrapInSoapEnvelope(string xmlContent)
    {
        return $@"
        <soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
            <soap:Body>
                {xmlContent}
            </soap:Body>
        </soap:Envelope>";
    }
}