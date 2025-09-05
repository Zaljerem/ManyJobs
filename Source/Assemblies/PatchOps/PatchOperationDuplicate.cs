using System.Collections.Generic;
using System.Xml;
using Verse;

// Duplicates the given xpath (should be renamed or similar afterwards).
namespace ManyJobs.PatchOps
{
    public class PatchOperationDuplicate : PatchOperationPathed
    {
        protected override bool ApplyWorker(XmlDocument xml)
        {
            bool result = false;
            foreach (object item in xml.SelectNodes(xpath))
            {
                XmlNode xmlNode = item as XmlNode;
                XmlNode parentNode = xmlNode.ParentNode;
                if( parentNode != null )
                {
                    result = true;
                    parentNode.AppendChild(xmlNode.OwnerDocument.ImportNode(xmlNode, deep: true));
                }
            }
            return result;
        }
    }
}
