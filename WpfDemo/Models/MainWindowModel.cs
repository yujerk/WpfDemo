using System.Collections.ObjectModel;
using WpfDemo.View;
namespace WpfNavigationTutorial.Model
{
    public class MainWindowModel
    {

        public ObservableCollection<NavigationItem> NavigationItems { get; } =
        new ObservableCollection<NavigationItem>()
        {
            new NavigationItem()
            {
                Title = "学生信息管理",
                Description = "The main page of this application",

                TargetPageType = typeof(StudentView)
            },
            new NavigationItem()
            {
                Title = "Configuration",
                Description = "Configure something you want",

                TargetPageType = typeof(CourseView)
            }
        };
        
    }

}
