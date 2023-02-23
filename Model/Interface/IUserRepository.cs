using System.Linq.Expressions;
namespace Model.Interface
{
    public interface IUserRepository<Tkey, TEnitity>
    {
        //A Get metódus egy lambda kifejezést vár bemenetként, amely egy TEntity típusú paramétert vesz át, és egy bool típusú értéket ad vissza.
        //A lambda kifejezés ebben az esetben a Get metódus lekérdezési feltételét határozza meg, amelyet az adatbázisban az entitásokra alkalmaznak.
        //A Get metódus visszatérési értéke a TEntity típusú entitás, amelyet a lekérdezési feltétel alapján találtak az adatbázisban.
        public TEnitity Get(Expression<Func<TEnitity, bool>> predicate);
    }
}
