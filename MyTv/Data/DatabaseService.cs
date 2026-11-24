
using SQLite;
using MyTv.Models;

namespace MyTv.Data
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection database;

        public DatabaseService()
        {
            string dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "MyTv.db3");

            database = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitializeDatabase()
        {
            await database.CreateTableAsync<User>();
            await database.CreateTableAsync<MediaItem>();
            await database.CreateTableAsync<WatchlistItem>();
            await database.CreateTableAsync<Rating>();
        }
        public async Task<int> AddUser(User user)
        {
            return await database.InsertAsync(user);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await database.Table<User>()
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();
        }
        public async Task<int> UpdateUser(User user)
        {
            return await database.UpdateAsync(user);
        }
    }
}
