using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetailPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            profileImage.Source = ImageSource.FromFile("euronics.png");
            aboutList.ItemsSource = GetMenuList();
            var homePage = typeof(Views.AboutPage);
            Detail = new NavigationPage((Page)Activator.CreateInstance(homePage));
            IsPresented = false;
        }

        public List<MasterMenuItems> GetMenuList()
        {
            var list = new List<MasterMenuItems>();
            list.Add(new MasterMenuItems()
            {
                Text = "Meist",
                Detail = "Luhike info",
                Imagepath = "about.png",
                Targetpage = typeof(Views.AboutPage)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Asukoht",
                Detail = "Asukoht",
                Imagepath = "list.png",
                Targetpage= typeof(Views.ExperiencePage)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Registreeruge tööle",
                Detail = "Registreeruge tööle",
                Imagepath = "skills.png",
                Targetpage = typeof(Views.SkillsPage)
                
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Rohkem",
                Detail = "Rohkem",
                Imagepath = "awards.png",
                Targetpage = typeof(Views.AchievemnetsPage)
            });

            return list;
        }

        private void aboutList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItems = (MasterMenuItems)e.SelectedItem;
            Type selectedPage = selectedMenuItems.Targetpage;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
            IsPresented = false;
        }
    }
}