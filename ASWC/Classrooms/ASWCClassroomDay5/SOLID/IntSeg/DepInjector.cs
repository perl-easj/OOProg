using SOLID.IntSeg.Catalogs;
using SOLID.IntSeg.Clients;
using SOLID.IntSeg.Decorators;

namespace SOLID.IntSeg
{
    public class DepInjector<T>
    {
        public DepInjector()
        {
            #region Creating Catalog and Client objectys
            
            // Implements ICreateReadUpdateDelete
            CatalogV1<T> catalogV1 = new CatalogV1<T>();


            // Implements ICreate, IRead, IUpdate, IDelete
            CatalogV2<T> catalogV2 = new CatalogV2<T>();


            // OK, since catalogV1 implements ICreateReadUpdateDelete
            ClientV1<T> clientV1catV1 = new ClientV1<T>(catalogV1);


            // NOT OK, since catalogV2 doesn't implement ICreateReadUpdateDelete
            // ClientV1<T> clientV1catV2 = new ClientV1<T>(catalogV2); 


            // NOT OK, since catalogV1 doesn't implement IDelete
            // ClientV2<T> clientV2catV1 = new ClientV2<T>(catalogV1); 


            // OK, since catalogV2 implements IDelete
            ClientV2<T> clientV2catV2 = new ClientV2<T>(catalogV2);

            #endregion


            #region Using the Delete decorator
            
            // NOT OK,since catalogV1 doesn't implement IDelete 
            // DeleteWithConfirmImpl<T> deleteImplV1 = new DeleteWithConfirmImpl<T>(catalogV1);


            // OK, since catalogV2 implements IDelete 
            DeleteWithConfirmImpl<T> deleteImplV2 = new DeleteWithConfirmImpl<T>(catalogV2);


            // OK, since deleteImpl implements IDelete
            ClientV2<T> clientV2deleteImpl = new ClientV2<T>(deleteImplV2);

            #endregion


            #region Creating Adapted Catalog objects

            // OK, since AdaptedCatalog constructor takes no parameters
            AdaptedCatalog<T> adapCat = new AdaptedCatalog<T>();


            // OK... but no way to "decorate" catalog implementation
            ClientV1<T> clientV1adapCat = new ClientV1<T>(adapCat);

            #endregion


            #region Creating Decorated Catalog objects

            // NOT OK, since catalogV1 doesn't implement ICreate, IRead, IUpdate, IDelete
            // DecoratedCatalog<T> confCatalogV1 = new DecoratedCatalog<T>(catalogV1, catalogV1, catalogV1, catalogV1);


            // OK, since catalogV2 implements ICreate, IRead, IUpdate, IDelete
            DecoratedCatalog<T> decoCatalog = new DecoratedCatalog<T>(catalogV2, catalogV2, catalogV2, catalogV2);


            // ALSO OK; since catalogV2 implements ICreate, IRead, IUpdate, and deleteImpl implements IDelete
            DecoratedCatalog<T> decoCatalogMixed = new DecoratedCatalog<T>(catalogV2, catalogV2, catalogV2, deleteImplV2);

            #endregion


            #region Using Decorated Catalog objects
            
            // OK, since decoCatalogV2 implements ICreateReadUpdateDelete
            ClientV1<T> clientV1decoCatV2 = new ClientV1<T>(decoCatalog);


            // ALSO OK, since decoCatalogMixed implements ICreateReadUpdateDelete
            ClientV1<T> clientV1decoCatMixed = new ClientV1<T>(decoCatalogMixed); 

            #endregion
        }
    }
}