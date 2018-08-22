using AddOns.Images.Implementation;
using AddOns.Images.Interfaces;
using AddOns.Security.Implementation;
using AddOns.Security.Interfaces;

namespace Extensions.AddOns.Implementation
{
    /// <summary>
    /// The ServiceProvider is simply intended 
    /// to hold together the various services 
    /// included in a project. The current version 
    /// only holds the Image and Security service.
    /// </summary>
    public class ServiceProvider
    {
        #region Singleton implementation
        private static ServiceProvider _instance;

        public static ServiceProvider Instance
        {
            get { return _instance ?? (_instance = new ServiceProvider()); }
        }
        #endregion

        #region Instance fields
        private ImageService _imageService;
        private SecurityService _securityService;
        #endregion

        #region Constructor
        private ServiceProvider()
        {
            _imageService = new ImageService();
            _securityService = new SecurityService(new UserType(), new ItemAccess());
        }
        #endregion

        #region Shorthands to access services through Singleton
        public static IImageService Images
        {
            get { return Instance._imageService; }
        }

        public static ISecurityService Security
        {
            get { return Instance._securityService; }
        }
        #endregion
    }
}