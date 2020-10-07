using AggregateRoot.Core.DomainObjects;
using System.Collections.Generic;
using System.Linq;

namespace AggregateRoot.Domain.Entities
{
    public class FarmArea : Entity, IAggregateRoot
    {
        private readonly List<FarmAreaCoordinate> _farmAreaCoordinates;

        protected FarmArea()
        {
        }

        public FarmArea(string name)
        {
            Name = name;
            _farmAreaCoordinates = new List<FarmAreaCoordinate>();
        }

        public string Name { get; private set; }

        public IReadOnlyList<FarmAreaCoordinate> FarmAreaCoordinates => _farmAreaCoordinates;

        public void AddCoordinate(decimal latitude, decimal longitude)
        {
            if (!ExistsCoordinate(latitude, longitude))
            {
                var coordinate = new FarmAreaCoordinate(latitude, longitude);
                coordinate.Validate();

                _farmAreaCoordinates.Add(coordinate);
            }
        }

        private bool ExistsCoordinate(decimal latitude, decimal longitude)
        {
            var coordinateItem = _farmAreaCoordinates?.FirstOrDefault(i => i.Latitude == latitude && i.Longitude == longitude);
            return (coordinateItem != null);
        }


        public override void Validate()
        {
            AssertionConcern.NotEmpty(Name, "Nome deve ser preenchido");
            AssertionConcern.IsTrue(_farmAreaCoordinates.Count > 2, "Coordenadas devem ser preenchidas no mínimo 3 coordenadas");
        }
    }
}
