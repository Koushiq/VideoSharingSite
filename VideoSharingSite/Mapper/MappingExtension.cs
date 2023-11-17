using VideoSharingSite.DbModels;
using VideoSharingSite.Models;

namespace VideoSharingSite.Mapper
{
    public static class MappingExtension
    {
        private static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            //use AutoMapper for mapping objects
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }
        private static TDestination Map<TDestination>(this object source)
        {
            //use AutoMapper for mapping objects
            return AutoMapperConfiguration.Mapper.Map<TDestination>(source);
        }
        public static TModel ToModel<TEntity, TModel>(this TEntity entity, TModel model)
           where TEntity : BaseEntity where TModel : BaseModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return entity.MapTo(model);
        }

        public static TEntity ToEntity<TEntity>(this BaseModel model) where TEntity : BaseEntity
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return model.Map<TEntity>();
        }
    }
}
