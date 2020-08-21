using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.DataLayer.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T t);
        void Update(T t);
        void Delete(int id);
    }
}
//Метод GetAll возвращает список всех объектов типа<T>.
//Метод Get ищет объект в базе данных по заданному id.
//Метод Find осуществляет поиск объекта, удовлетворяющего условию predicate.
//Метод Create добавляет объект типа<T> в базу данных. 
//Метод Update принимает измененный объект типа <T> и вносит изменения в базу данных.
//А все остальные репозитории будут на основании этого интерфейса.
