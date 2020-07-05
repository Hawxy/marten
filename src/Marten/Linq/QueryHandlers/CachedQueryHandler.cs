using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Marten.Linq.Compiled;
using Marten.Services;
using Marten.Util;
using Marten.V4Internals;
using Npgsql;

namespace Marten.Linq.QueryHandlers
{
    internal class CachedQueryHandler<T>: IQueryHandler<T>
    {
        private readonly object _model;
        private readonly NpgsqlCommand _template;
        private readonly IQueryHandler<T> _handler;
        private readonly IDbParameterSetter[] _setters;
        private readonly ISerializer _serializer;

        public CachedQueryHandler(object model, NpgsqlCommand template, IQueryHandler<T> handler, IDbParameterSetter[] setters, ISerializer serializer)
        {
            _model = model;
            _template = template;
            _handler = handler;
            _setters = setters;
            _serializer = serializer;
        }

        public void ConfigureCommand(CommandBuilder builder, IMartenSession session)
        {
            var sql = _template.CommandText;
            for (var i = 0; i < _setters.Length && i < _template.Parameters.Count; i++)
            {
                var param = _setters[i].AddParameter(_model, builder);

                if (param.Value is Enum)
                {
                    if (_serializer.EnumStorage == EnumStorage.AsInteger)
                        param.Value = (int)param.Value;
                    else
                        param.Value = param.Value;
                }

                param.NpgsqlDbType = _template.Parameters[i].NpgsqlDbType;

                sql = sql.Replace(":" + _template.Parameters[i].ParameterName, ":" + param.ParameterName);
            }

            builder.Append(sql);
        }

        public T Handle(DbDataReader reader, IMartenSession session)
        {
            return _handler.Handle(reader, session);
        }

        public Task<T> HandleAsync(DbDataReader reader, IMartenSession session, CancellationToken token)
        {
            return _handler.HandleAsync(reader, session, token);
        }
    }
}
