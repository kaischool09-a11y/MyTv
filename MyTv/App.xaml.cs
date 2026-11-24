using MyTv.Data;

namespace MyTv
{
    public partial class App : Application
    {
        private DatabaseService databaseService;

        public App(DatabaseService database)
        {
            InitializeComponent();

            databaseService = database;

            Task.Run(async () =>
            {
                await databaseService.InitializeDatabase();
            });
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}