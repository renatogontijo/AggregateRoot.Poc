using AggregateRoot.Core.DomainObjects;

namespace AggregateRoot.Domain.Entities
{
    public class FarmAreaCoordinate : Entity
    {
        protected FarmAreaCoordinate()
        {
        }

        public FarmAreaCoordinate(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;

            Validate();
        }

        public long FarmAreaId { get; protected set; }

        public decimal Latitude { get; private set; }

        public decimal Longitude { get; private set; }

        public FarmArea FarmArea { get; private set; }

        public override void Validate()
        {
            AssertionConcern.NotEqual(Latitude, 0, "Latitude deve ser diferente de zero");
            AssertionConcern.NotEqual(Longitude, 0, "Latitude deve ser diferente de zero");
        }
    }
}
