﻿using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        public ParkingLotService()
        {

        }

        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new ArgumentException();
            }
            return new ParkingLot
            { 
                Name = parkingLotDto.Name,
                Id  = Guid.NewGuid().ToString(),
                Location = parkingLotDto.Location,
                Capacity = parkingLotDto.Capacity,
            };
        }
    }
}