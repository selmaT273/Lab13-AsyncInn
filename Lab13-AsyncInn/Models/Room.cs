using System;
namespace Lab13_AsyncInn.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoomLayout Layout { get; set; }

    }

    public enum RoomLayout
    {
        Single,
        Double,
        Triple,
        Quad,
        Quint
    }
}
