using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string XmlParser(XmlDocument xmlDoc)
    {
        try
        {
            if (xmlDoc != null)
            {
                XmlNode declarationNode = xmlDoc.SelectSingleNode("/InputDocument/DeclarationList/Declaration");
                XmlNode siteID = xmlDoc.SelectSingleNode("/InputDocument/DeclarationList/Declaration/DeclarationHeader/SiteID");

                if (declarationNode.Attributes["Command"].InnerText != "DEFAULT")
                {
                    return "-1";
                }

                if (siteID.InnerText != "DUB")
                {
                    return "-2";
                }

                else
                {
                    return "0"; 
                }
            }
            else
            {
                return "Please pass the XML";
            }
        }
        catch (Exception ex)
        {
            return "Incorrect XML formart";
        }
    }
    
}
