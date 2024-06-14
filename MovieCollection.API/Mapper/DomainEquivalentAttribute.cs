namespace MovieCollection.API.Mapper
{
    public class DomainEquivalentAttribute:Attribute
    {
        public Type DomainModelType { get; private set; }
        public DomainEquivalentAttribute(Type domainModelType)
        {
            DomainModelType = domainModelType;
        }
    }
}
