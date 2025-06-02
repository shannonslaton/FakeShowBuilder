using FakeShowBuilder.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

namespace FakeShowBuilder
{
    [Route("api/[controller]")]
    [ApiController]
    public class VectorworksExchangeController : ControllerBase
    {
        [HttpPost("vwhello")]
        public async Task<IActionResult> VwHello(string theText)
        {
            await Task.Delay(100);
            

            return Ok("true");
        }
        [HttpPost("vwpushchanges")]
        public async Task<IActionResult> VwPushChanges([FromBody] PassObject passObject)
        {
            await Task.Delay(100);
            if (!string.IsNullOrEmpty(passObject.xmlString))
            {
                // Convert getResult (string) to XDocument (parsed XML)
                try
                {
                    var xDoc = System.Xml.Linq.XDocument.Parse(passObject.xmlString);
                    // You can now work with xDoc as needed
                }
                catch (System.Xml.XmlException ex)
                {
                    // Handle invalid XML
                }
            }

            return Ok("true");
        }

        [HttpPost("vwgetchanges")]
        public async Task<IActionResult> VmGetChanges([FromBody] PassObject passObject)
        {
            await Task.Delay(100);
            // Create a XAML/XML object
            var xamlElement = new XElement("Button",
            new XAttribute("Width", "100"),
            new XAttribute("Height", "30"),
            new XAttribute("Content", "Click Me")
            );

            // Convert the XElement to a string
            string xmlString = xamlElement.ToString();

            passObject = new PassObject()
            {
                urlGuid = passObject.urlGuid,
                xmlString = xmlString
            };

            return Ok(passObject);
        }
    }
}
