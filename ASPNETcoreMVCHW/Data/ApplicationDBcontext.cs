using ASPNETcoreMVCHW.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETcoreMVCHW.Data
{
    public class ApplicationDBcontext: DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options): base(options)
        {

        }
        public virtual DbSet<CakeRecipes> Recipes { get; set; }
    }
}
