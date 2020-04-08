using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;


namespace SharpPlanner
{
    // Database implentation based off https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/data/databases#install-the-sqlite-nuget-package

    public class PlanDB
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DBConfig.DatabasePath, DBConfig.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public PlanDB()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Plan).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Plan)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<Plan>> GetItemsAsync()
        {
            return Database.Table<Plan>().ToListAsync();
        }

        public Task<List<Plan>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Plan>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Plan> GetItemAsync(int id)
        {
            return Database.Table<Plan>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Plan item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Plan item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
