using System;
using System.Net;

namespace DICOMcloud.Examples.Net
{
    class QidoExample
    {
        public void QueryStudies ( ) 
        {
            WebClient client = new WebClient ( ) ;
            
            string queryUrl = "https://dicomcloud.azurewebsites.net/qidors/studies?00100010=dcloud";
            
            //Query as JSON data
            client.Headers.Add ( "Accept", "application/dicom+json") ;

            string jsonResponse = client.DownloadString (queryUrl) ;

            //Query as XML data
            client.Headers ["Accept"] = "multipart/related; type=\"application/dicom+xml\"" ;

            string xmlResponse = client.DownloadString (queryUrl) ;

            Console.Write ( jsonResponse ) ;
            Console.Write ( xmlResponse ) ;
        }
    }
}
