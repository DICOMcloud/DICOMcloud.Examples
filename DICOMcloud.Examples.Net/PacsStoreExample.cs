using Dicom;
using DICOMcloud.DataAccess;
using DICOMcloud.DataAccess.Database;
using DICOMcloud.DataAccess.Database.Schema;
using DICOMcloud.IO;
using DICOMcloud.Media;
using DICOMcloud.Pacs;
using DICOMcloud.Pacs.Commands;

namespace DICOMcloud.Examples.Net
{
    class PacsStoreExample
    {
        public void StoreDataset ( DicomDataset dataset, string storagePath, string databaseConnectionString )
        {
            IObjectStoreService StoreService = CreateStorageService (storagePath, databaseConnectionString);

            StoreService.StoreDicom(dataset, new InstanceMetadata());
        }

        private static IObjectStoreService CreateStorageService(string storagePath, string databaseConnectionString)
        {
            IDicomMediaIdFactory      mediaIdFactory = new DicomMediaIdFactory        ( ) ;
            IMediaStorageService      storageService = new FileStorageService         ( storagePath ) ;
            DbSchemaProvider          schemaProvider = new StorageDbSchemaProvider    ( ) ;
            IDatabaseFactory          databaseFacory = new SqlDatabaseFactory         ( databaseConnectionString) ;
            ObjectArchieveDataAdapter dataAdapter    = new ObjectArchieveDataAdapter  ( schemaProvider, databaseFacory ) ;
            IObjectArchieveDataAccess dataAccess     = new ObjectArchieveDataAccess   ( databaseConnectionString,
                                                                                        schemaProvider,
                                                                                        dataAdapter ) ;
            IDicomMediaWriterFactory mediaWriterFactory = new DicomMediaWriterFactory ( storageService, 
                                                                                        mediaIdFactory ) ;                                                                                        
            IDCloudCommandFactory factory = new DCloudCommandFactory ( storageService,
                                                                       dataAccess,
                                                                       mediaWriterFactory,
                                                                       mediaIdFactory ) ;
            
            IObjectStoreService StoreService = new ObjectStoreService ( factory ) ;

            return StoreService;
        }
    }
}
