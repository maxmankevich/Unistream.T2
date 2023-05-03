using Microsoft.AspNetCore.Mvc;
using Unistream.T2.Business.Handlers;
using Unistream.T2.Domain.Entities;
using Unistream.T2.Service.Attributes.Filters;
using Unistream.T2.Service.Converters;

namespace Unistream.T2.Service.Api
{
    [Route("")]
    [ApiController]
    public class EntityController : Controller
    {
        private readonly IEntityHandler _entityHandler;
        private readonly IJsonConverter _jsonConverter;

        public EntityController(IEntityHandler entityHandler, IJsonConverter jsonConverter)
        {
            _entityHandler = entityHandler;
            _jsonConverter = jsonConverter;
        }

        /// <summary>
        /// Получить объект Entity по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>
        /// Объект Entity с искомым идентификатором
        /// </returns>
        /// <remarks>
        /// Примеры запросов:
        ///
        ///     GET /?get=cfaa0d3f-7fea-4423-9f69-ebff826e2f89
        ///
        /// </remarks>
        /// <response code="200">Объект Entity</response>
        /// <response code="404">Если объект не найден</response>
        [HttpGet]
        public ActionResult<Entity> Get([FromQuery(Name = "get")]Guid id)
        {
            Entity? entity = _entityHandler.GetById(id);

            if (entity == null)
            {
                return this.NotFound();
            }

            return this.Ok(_jsonConverter.Serialize(entity));
        }

        /// <summary>
        /// Сохранить объект Entity
        /// </summary>
        /// <param name="json">Json строка с полями объекта Entity</param>
        /// <returns>
        /// Статус выполнения запроса
        /// </returns>
        /// <remarks>
        /// Примеры запросов:
        ///
        ///     PUT /?insert={"id":"cfaa0d3f-7fea-4423-9f69-ebff826e2f89","operationDate":"2019-04-02T13:10:20.0263632+03:00","amount":23.05}
        ///
        /// </remarks>
        /// <response code="204">Объект сохранен</response>
        /// <response code="400">Если передана невалидная модель объекта</response>
        [NormalizeQueryStringResourceFilter]
        [HttpPut] // в текущей реализации корректнее использовать PUT согласно его назначению в REST
        public ActionResult Create([FromQuery(Name = "insert")] string json)
        {
            Entity? model;

            try
            {
                model = _jsonConverter.Deserialize<Entity>(json);

                if (model == null)
                {
                    throw new Exception("Can't be deserialized");
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest($"Serialization error: {ex.Message}");
            }

            _entityHandler.CreateOrUpdate(model);

            return this.NoContent();
        }
    }
}
