namespace NET_Restaurant_API.Models.Base
{
	public interface IBaseEntity
	{
		Guid Id { get; set; }

		DateTime DataCreated { get; set; }
		DateTime? DateModified { get; set; }
	}
}

