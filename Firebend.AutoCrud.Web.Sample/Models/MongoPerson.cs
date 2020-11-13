using System;
using Firebend.AutoCrud.Core.Extensions;
using Firebend.AutoCrud.Core.Interfaces.Models;

namespace Firebend.AutoCrud.Web.Sample.Models
{
    public class MongoPerson : IEntity<Guid>, IActiveEntity, IModifiedEntity
    {
        public MongoPerson()
        {
        }

        public MongoPerson(PersonViewModel viewModel)
        {
            viewModel.CopyPropertiesTo(this);
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsDeleted { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
    }
}