using CMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.UnitOfWork
{
    public interface IUoW
    {
        PostRepository PostRepository { get; }
        TagRepository TagRepository { get; }
        GeneralSettingsRepository GeneralSettingsRepository { get; }

        Task SaveAsync();
    }
}
