using Microsoft.EntityFrameworkCore;
using ONIT_Laba1.Data.Models;

namespace ONIT_Laba1.Data.Repositories;
public class SongRepository : ISongRepository
{
    private readonly AppDbContext _db;

    public SongRepository(AppDbContext db)
    {
        _db = db;
    }

    public void Add(Song song)
    {
        _db.Songs.Add(song);

        _db.SaveChanges();
    }

    public void Delete(Song song)
    {
        _db.Remove(song);

        _db.SaveChanges();
    }

    public IEnumerable<Song> GetAll()
    {
        var result= _db.Songs.Select(s => s).ToList();
        return result;
    }

    public Song GetById(int id)
    {
        return _db.Songs.Find(id);
    }

    public void Update(Song song)
    {
        _db.Songs.Update(song);

        _db.SaveChanges();

    }
}
