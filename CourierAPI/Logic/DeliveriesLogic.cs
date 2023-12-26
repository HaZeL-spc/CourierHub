using CourierAPI.Helpers;
using CourierAPI.Models;
using CourierAPI.Services;
using CourierAPI.Services.Converters;
using System.Threading;

namespace CourierAPI.Logic
{
    public interface IDeliveriesLogic
    {
        public Task<Result> CancelDelivery(DeliveryDto d, CancellationToken cancellationToken);
        public Task<Result> DeliverDelivery(DeliveryDto d, CancellationToken cancellationToken);
        public Task<Result> PickUpDelivery(DeliveryDto d, CancellationToken cancellationToken);
    }

    public class DeliveriesLogic : IDeliveriesLogic
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IDeliveryConverter _deliveryConverter;

        public DeliveriesLogic(IDeliveryRepository deliveryRepository
            , IDeliveryConverter deliveryConverter)
        {
            _deliveryConverter = deliveryConverter;
            _deliveryRepository = deliveryRepository;
        }

        public async Task<Result> CancelDelivery(DeliveryDto d, CancellationToken cancelToken)
        {
            var getResponse = await _deliveryRepository.GetDelivery(d.Id, cancelToken);

            if (!getResponse.Success) return Result.Fail($"Repository error: {getResponse.Error}");

            DeliveryModel model = new DeliveryModel(getResponse.Value);
            model.SetCancelled();

            d = _deliveryConverter.ModelToDto(model);

            var updateResponse = await _deliveryRepository.UpdateDelivery(d);

            return updateResponse.Success
                ? Result.Ok()
                : Result.Fail(updateResponse.Error);
        }

        public async Task<Result> DeliverDelivery(DeliveryDto d, CancellationToken cancellationToken)
        {
            var getResponse = await _deliveryRepository.GetDelivery(d.Id, cancellationToken);

            if (!getResponse.Success) return Result.Fail($"Repository error: {getResponse.Error}");

            DeliveryModel model = new DeliveryModel(getResponse.Value);
            model.SetDelivered();

            d = _deliveryConverter.ModelToDto(model);

            var updateResponse = await _deliveryRepository.UpdateDelivery(d);

            return updateResponse.Success
                ? Result.Ok()
                : Result.Fail(updateResponse.Error);
        }

        public async Task<Result> PickUpDelivery(DeliveryDto d, CancellationToken cancellationToken)
        {
            var getResponse = await _deliveryRepository.GetDelivery(d.Id, cancellationToken);

            if (!getResponse.Success) return Result.Fail($"Repository error: {getResponse.Error}");

            DeliveryModel model = new DeliveryModel(getResponse.Value);
            model.SetPickedUp();

            d = _deliveryConverter.ModelToDto(model);

            var updateResponse = await _deliveryRepository.UpdateDelivery(d);

            return updateResponse.Success
                ? Result.Ok()
                : Result.Fail(updateResponse.Error);
        }
    }
}
