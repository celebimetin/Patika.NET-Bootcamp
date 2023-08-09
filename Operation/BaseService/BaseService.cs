using AutoMapper;
using Core.Model;
using Core.SharedLibrary.Dtos;
using Core.SharedLibrary.Messages;
using Data.UnitOfWork;
using Schema.Mapper;

namespace Operation.BaseService
{
    public class BaseService<TEntity, TRequest, TResponse> : IBaseService<TEntity, TRequest, TResponse>
        where TEntity : BaseEntity
        where TRequest : class
        where TResponse : class
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Response<List<TResponse>> GetAll()
        {
            try
            {
                var entities = unitOfWork.Repository<TEntity>().GetList();
                var mapped = ObjectMapper.Mapper.Map<List<TEntity>, List<TResponse>>(entities);
                return Response<List<TResponse>>.Success(mapped, 200);
            }
            catch (Exception ex)
            {
                return Response<List<TResponse>>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<Response<IEnumerable<TResponse>>> GetAllAsync()
        {
            try
            {
                var entities = await unitOfWork.Repository<TEntity>().GetListAsync();
                var mapped = ObjectMapper.Mapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(entities);
                return Response<IEnumerable<TResponse>>.Success(mapped, 200);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<TResponse>>.Fail(ex.Message, 500, true);
            }
        }

        public Response<TResponse> GetById(int id)
        {
            try
            {
                var entity = unitOfWork.Repository<TEntity>().Get(id);
                if (entity is null)
                    return Response<TResponse>.Fail(Message.NotFound, 404, true);

                var mapped = ObjectMapper.Mapper.Map<TEntity, TResponse>(entity);
                return Response<TResponse>.Success(mapped, 200);
            }
            catch (Exception ex)
            {
                return Response<TResponse>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<Response<TResponse>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await unitOfWork.Repository<TEntity>().GetAsync(id);
                if (entity is null)
                    return Response<TResponse>.Fail(Message.NotFound, 404, true);

                var mapped = ObjectMapper.Mapper.Map<TEntity, TResponse>(entity);
                return Response<TResponse>.Success(mapped, 200);
            }
            catch (Exception ex)
            {
                return Response<TResponse>.Fail(ex.Message, 500, true);
            }
        }

        public Response<TResponse> Add(TRequest request)
        {
            try
            {
                var entity = ObjectMapper.Mapper.Map<TRequest, TEntity>(request);
                var addEntity = unitOfWork.Repository<TEntity>().Add(entity);
                unitOfWork.SaveChanges();
                var mapped = ObjectMapper.Mapper.Map<TEntity, TResponse>(addEntity);
                return Response<TResponse>.Success(mapped, 200);
            }
            catch (Exception ex)
            {
                return Response<TResponse>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<Response<TResponse>> AddAsync(TRequest request)
        {
            try
            {
                var entity = ObjectMapper.Mapper.Map<TRequest, TEntity>(request);
                var addEntity = await unitOfWork.Repository<TEntity>().AddAsync(entity);
                await unitOfWork.SaveChangesAsync();
                var mapped = ObjectMapper.Mapper.Map<TEntity, TResponse>(addEntity);
                return Response<TResponse>.Success(mapped, 200);
            }
            catch (Exception ex)
            {
                return Response<TResponse>.Fail(ex.Message, 500, true);
            }
        }

        public virtual Response<NoDataDto> Update(TRequest request, int id)
        {
            try
            {
                var checkEntity = unitOfWork.Repository<TEntity>().Get(id);
                if (checkEntity is null)
                    return Response<NoDataDto>.Fail(Message.NotFound, 404, true);

                var entity = ObjectMapper.Mapper.Map<TRequest, TEntity>(request);
                entity.Id = id;
                var updateEntity = unitOfWork.Repository<TEntity>().Update(entity);
                unitOfWork.SaveChanges();
                var mapped = ObjectMapper.Mapper.Map<TEntity, TResponse>(updateEntity);
                return Response<NoDataDto>.Success(204);
            }
            catch (Exception ex)
            {
                return Response<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }

        public virtual Response<NoDataDto> DeleteById(int id)
        {
            try
            {
                var checkEntity = unitOfWork.Repository<TEntity>().Get(id);
                if (checkEntity is null)
                    return Response<NoDataDto>.Fail(Message.NotFound, 404, true);

                var deleteEntity = unitOfWork.Repository<TEntity>().DeleteById(id);
                unitOfWork.SaveChanges();
                return Response<NoDataDto>.Success(204);
            }
            catch (Exception ex)
            {
                return Response<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }

        public Response<NoDataDto> RemoveRange(TRequest request, int id)
        {
            try
            {
                var checkEntity = unitOfWork.Repository<TEntity>().Get(id);
                if (checkEntity is null)
                    return Response<NoDataDto>.Fail(Message.NotFound, 404, true);

                var entity = ObjectMapper.Mapper.Map<TRequest, TEntity>(request);
                entity.Id = id;
                var deleteEntity = unitOfWork.Repository<TEntity>().RemoveRange(entity);
                unitOfWork.SaveChanges();
                var mapped = ObjectMapper.Mapper.Map<TEntity, TResponse>(deleteEntity);
                return Response<NoDataDto>.Success(204);
            }
            catch (Exception ex)
            {
                return Response<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }
    }
}