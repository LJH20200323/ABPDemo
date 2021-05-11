using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Authors
{
    /// <summary>
    /// 作者应用层域服务
    /// </summary>
    public interface IAuthorAppService: IApplicationService
    {
        /// <summary>
        /// 根据作者ID查询作者数据
        /// </summary>
        /// <param name="id">作者ID</param>
        /// <returns>作者实体</returns>
        Task<AuthorDto> GetAsync(Guid id);

        /// <summary>
        /// 根据查询条件查询作者数据
        /// 模糊查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns>区间数据</returns>
        Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input);

        /// <summary>
        /// 创建作者Dto创建实体
        /// </summary>
        /// <param name="input">作者Dto创建实体</param>
        /// <returns>作者Dto实体</returns>
        Task<AuthorDto> CreateAsync(CreateAuthorDto input);

        /// <summary>
        /// 创建作者Dto修改实体
        /// </summary>
        /// <param name="id">作者ID</param>
        /// <param name="input">作者Dto修改实体</param>
        /// <returns>无</returns>
        Task UpdateAsync(Guid id,UpdateAuthorDto input);

        /// <summary>
        /// 根据作者ID删除作者
        /// </summary>
        /// <param name="id">作者Id</param>
        /// <returns>无</returns>
        Task DeleteAsync(Guid id);
    }
}
