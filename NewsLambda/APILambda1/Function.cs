using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using APILambda.Models;
using APILambda.Services;

// Assembly attribute to enable the Lambda function"s JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace APILambda
{
    public class Function
    {
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            APIGatewayProxyResponse response = new APIGatewayProxyResponse();
            string pathLocation = input.Path;
            if (input.HttpMethod == HttpMethod.Post.ToString())
            {
                if (pathLocation == "ModelDetailsInsert")
                {
                    ModelDetails ModelDetailsT = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelDetails>(input.Body);
                    ModelDetailsInsertController ModelDetailsinsert = new ModelDetailsInsertController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(ModelDetailsinsert.Post(ModelDetailsT));
                    response.StatusCode = 200;
                }

                if (pathLocation == "SoldCarsInsert")
                {
                    SoldCars SoldCarsT = Newtonsoft.Json.JsonConvert.DeserializeObject<SoldCars>(input.Body);
                    SoldCarsInsertController SoldCarsinsert = new SoldCarsInsertController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(SoldCarsinsert.Post(SoldCarsT));
                    response.StatusCode = 200;
                }

                if (pathLocation == "VehiclesInsert")
                {
                    Vehicles VehiclesT = Newtonsoft.Json.JsonConvert.DeserializeObject<Vehicles>(input.Body);
                    VehiclesInsertController Vehiclesinsert = new VehiclesInsertController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(Vehiclesinsert.Post(VehiclesT));
                    response.StatusCode = 200;
                }
            }

            if (input.HttpMethod == HttpMethod.Put.ToString())
            {
                if (pathLocation == "ModelDetailsUpdate")
                {
                    ModelDetails ModelDetailsT = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelDetails>(input.Body);
                    ModelDetailsUpdateController ModelDetailsUpdate = new ModelDetailsUpdateController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(ModelDetailsUpdate.Post(ModelDetailsT));
                    response.StatusCode = 200;
                }

                if (pathLocation == "SoldCarsUpdate")
                {
                    SoldCars SoldCarsT = Newtonsoft.Json.JsonConvert.DeserializeObject<SoldCars>(input.Body);
                    SoldCarsUpdateController SoldCarsUpdate = new SoldCarsUpdateController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(SoldCarsUpdate.Post(SoldCarsT));
                    response.StatusCode = 200;
                }

                if (pathLocation == "VehiclesUpdate")
                {
                    Vehicles VehiclesT = Newtonsoft.Json.JsonConvert.DeserializeObject<Vehicles>(input.Body);
                    VehiclesUpdateController VehiclesUpdate = new VehiclesUpdateController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(VehiclesUpdate.Post(VehiclesT));
                    response.StatusCode = 200;
                }
            }

            if (input.HttpMethod == HttpMethod.Delete.ToString())
            {
                if (pathLocation == "ModelDetailsDelete")
                {
                    DeleteModel DeleteModelT = Newtonsoft.Json.JsonConvert.DeserializeObject<DeleteModel>(input.Body);
                    ModelDetailsDeleteController ModelDetailsDelete = new ModelDetailsDeleteController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(ModelDetailsDelete.Delete(DeleteModelT));
                    response.StatusCode = 200;
                }

                if (pathLocation == "SoldCarsDelete")
                {
                    DeleteModel DeleteModelT = Newtonsoft.Json.JsonConvert.DeserializeObject<DeleteModel>(input.Body);
                    SoldCarsDeleteController SoldCarsDelete = new SoldCarsDeleteController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(SoldCarsDelete.Delete(DeleteModelT));
                    response.StatusCode = 200;
                }

                if (pathLocation == "VehiclesDelete")
                {
                    DeleteModel DeleteModelT = Newtonsoft.Json.JsonConvert.DeserializeObject<DeleteModel>(input.Body);
                    VehiclesDeleteController VehiclesDelete = new VehiclesDeleteController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(VehiclesDelete.Delete(DeleteModelT));
                    response.StatusCode = 200;
                }
            }

            if (input.HttpMethod == HttpMethod.Get.ToString())
            {
                if (pathLocation == "ModelDetailsFilterSelect")
                {
                    FilterModel FilterModelT = Newtonsoft.Json.JsonConvert.DeserializeObject<FilterModel>(input.Body);
                    ModelDetailsFilterSelectController Select = new ModelDetailsFilterSelectController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(Select.Get(FilterModelT));
                    response.StatusCode = 200;
                }

                if (pathLocation == "SoldCarsFilterSelect")
                {
                    FilterModel FilterModelT = Newtonsoft.Json.JsonConvert.DeserializeObject<FilterModel>(input.Body);
                    SoldCarsFilterSelectController Select = new SoldCarsFilterSelectController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(Select.Get(FilterModelT));
                    response.StatusCode = 200;
                }

                if (pathLocation == "VehiclesFilterSelect")
                {
                    FilterModel FilterModelT = Newtonsoft.Json.JsonConvert.DeserializeObject<FilterModel>(input.Body);
                    VehiclesFilterSelectController Select = new VehiclesFilterSelectController();
                    response.Body = Newtonsoft.Json.JsonConvert.SerializeObject(Select.Get(FilterModelT));
                    response.StatusCode = 200;
                }
            }

            response.Body = pathLocation;
            return response;
        }
    }
}