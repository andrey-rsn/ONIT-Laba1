using ONIT_Laba1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIT_Laba1.Data.Repositories;

public interface ISongRepository
{
    IEnumerable<Song> GetAll ();
    Song GetById (int id);
    void Add(Song song);
    void Update(Song song);

    void Delete(Song song);
}
