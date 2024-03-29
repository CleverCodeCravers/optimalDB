using optimalDb.Domain;
using optimalDb.Domain.AutoUpdates;

namespace optimalDb.WinForms
{
    internal static class Program
    {
        static bool _autoUpdateTest = false;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var args = Environment.GetCommandLineArgs();
            _autoUpdateTest = args.Length > 1;

            // Only perform auto-updates if not in dev environment
            if (VersionInformation.Version != "$$VERSION$$" || _autoUpdateTest)
            {
                if (AutoUpdate())
                    return;
            }

            Application.Run(new DatabaseBrowserForm());
        }

        private static bool AutoUpdate()
        {
            var updater = new AutoUpdater(
                "OptimalDb",
                VersionInformation.Version,
                "https://api.github.com/repos/stho32/optimalDB/releases");

            if (updater.IsUpdateAvailable() || _autoUpdateTest)
            {
                DialogResult userGivesConsent = MessageBox.Show("There is a new update, do you want to install it now ?", "New Update", MessageBoxButtons.YesNo);

                if (userGivesConsent == DialogResult.Yes)
                {
                    updater.Update();
                    return true;
                }
            }

            return false;
        }
    }
}