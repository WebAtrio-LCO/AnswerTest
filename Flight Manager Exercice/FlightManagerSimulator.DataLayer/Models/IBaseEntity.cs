using System.ComponentModel.DataAnnotations;

namespace FlightManagerSimulator.DataLayer.Models
{
    /// <summary>
    /// Define the common data that an entity must define
    /// Note : Also used to identify which class is an entity
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// Get or Set the unique id of the entity in database
        /// </summary>
        [Key]
        int Id { get; set; }
    }
}
