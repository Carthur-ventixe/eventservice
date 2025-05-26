using WebApi.Data.Contexts;
using WebApi.Data.Entities;

namespace WebApi.Data.Repositories;

public class PackageRepository(DataContext context) : BaseRepository<PackageEntity>(context), IPackageRepository
{
}
