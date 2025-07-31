using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace TPLOCAL1.Models
{
    public class OpinionReader
    {
        public List<Opinion> GetOpinions(string filePath)
        {
            List<Opinion> opinionList = new List<Opinion>();
            XmlDocument xmlDoc = new XmlDocument();

            using (StreamReader streamDoc = new StreamReader(filePath))
            {
                string dataXml = streamDoc.ReadToEnd();
                xmlDoc.LoadXml(dataXml);
            }

            foreach (XmlNode node in xmlDoc.SelectNodes("root/row"))
            {
                string lastName = node["LastName"].InnerText;
                string firstName = node["FirstName"].InnerText;
                string opinionGiven = node["OpinionGiven"].InnerText;

                Opinion opinion = new Opinion
                {
                    LastName = lastName,
                    FirstName = firstName,
                    OpinionGiven = opinionGiven
                };
                opinionList.Add(opinion);
            }

            return opinionList;
        }
    }
}