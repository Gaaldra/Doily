using Microsoft.EntityFrameworkCore;

namespace Doily.API.Data;

public class DoilyContext(DbContextOptions dbContextOptions): DbContext(dbContextOptions)
{

}
