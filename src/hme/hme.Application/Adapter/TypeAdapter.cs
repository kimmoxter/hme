namespace hme.Application.Adapter
{
    using AutoMapper;

    public class TypeAdapter: ITypeAdapter
    {
        private IMapper mapper;

        public TypeAdapter(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return this.mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return this.mapper.Map<TTarget>(source);
        }
    }
}
