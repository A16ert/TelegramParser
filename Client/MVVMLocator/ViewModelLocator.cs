/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Client"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Client.BusinessLogic.Authorization;
using Client.BusinessLogic.Message;
using Client.ViewModel;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace Client.MVVMLocator
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AuthViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();

            ServicesRegister();
        }

        private void ServicesRegister()
        {
            SimpleIoc.Default.Register<IAuthService, AuthService>();
            SimpleIoc.Default.Register<IMessageService, MessageService>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AuthViewModel Auth
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AuthViewModel>();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}