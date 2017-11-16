using System.Net;

namespace DICOMcloud.Examples.Net
{
    class WadoUrlExample
    {
        public void DownloadDicom ( string studyUid, string seriesUid, string sopUid ) 
        {
            WebClient client = new WebClient ( ) ;
            
            string url = string.Format ( "http://localhost:44301/wadouri?RequestType=wado&studyUID={0}&seriesUID={1}&objectUID={2}&contentType=application/dicom",
                                          studyUid, seriesUid, sopUid ) ;
            
            client.Headers.Add ( "Accept", "application/dicom");

            //Or you just need to specify that you accept all media types:
            //client.Headers.Add ( "Accept", "*/*");
            
            System.IO.Stream dicomData = client.OpenRead ( url ) ;
        }
    }
}
