namespace escuela_it
{
    public interface IOrigin
    {
        bool contains(Tile[] tiles);
        void takeOut(Tile[] tiles);
    }
}