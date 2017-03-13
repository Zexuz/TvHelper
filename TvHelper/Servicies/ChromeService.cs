using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace TvHelper.Servicies
{
    public class ChromeService
    {
        public bool IsCromeRunning()
        {
            var procsChrome = Process.GetProcessesByName("chrome");
            foreach (var proc in procsChrome)
            {
                // the chrome process must have a window
                if (proc.MainWindowHandle != IntPtr.Zero)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task OpenChrome()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "chrome.exe",
                UseShellExecute = true
            });


            while (!IsCromeRunning())
            {
                await Task.Delay(100);
            }
        }

        public List<string> GetActiveTabs()
        {
            var chromeTabs = new List<string>();
            // there are always multiple chrome processes, so we have to loop through all of them to find the
// process with a Window Handle and an automation element of name "Address and search bar"
            Process[] procsChrome = Process.GetProcessesByName("chrome");
            if (procsChrome.Length <= 0)
            {
                Console.WriteLine("Chrome is not running");
            }
            else
            {
                foreach (Process proc in procsChrome)
                {
                    // the chrome process must have a window
                    if (proc.MainWindowHandle == IntPtr.Zero)
                    {
                        continue;
                    }
                    // to find the tabs we first need to locate something reliable - the 'New Tab' button
                    AutomationElement root = AutomationElement.FromHandle(proc.MainWindowHandle);
                    Condition condNewTab = new PropertyCondition(AutomationElement.NameProperty, "New Tab");
                    AutomationElement elmNewTab = root.FindFirst(TreeScope.Descendants, condNewTab);
                    // get the tabstrip by getting the parent of the 'new tab' button
                    TreeWalker treewalker = TreeWalker.ControlViewWalker;
                    AutomationElement elmTabStrip = treewalker.GetParent(elmNewTab);
                    // loop through all the tabs and get the names which is the page title
                    Condition condTabItem = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
                    foreach (AutomationElement tabitem in elmTabStrip.FindAll(TreeScope.Children, condTabItem))
                    {
                       chromeTabs.Add(tabitem.Current.Name);
                    }
                }
            }
            return chromeTabs;
        }

        public void OpenWindowInChrome(string url)
        {
            Process.Start(url);
        }
    }
}