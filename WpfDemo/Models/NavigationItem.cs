using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfDemo.Models
{
    public class NavigationItem
    {
        /// <summary>
        /// 导航标题
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 导航描述
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 目标页面的类型
        /// </summary>
        public Type TargetPageType { get; set; } = typeof(Page);
    }
}
