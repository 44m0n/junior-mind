import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { ApiController } from './api.controller';
import { MovieController } from './movie.controller';
import { MovieEntity } from './movie.entity';
import { MovieService } from './movie.service';

@Module({
    imports: [TypeOrmModule.forFeature([MovieEntity])],
    providers: [MovieService],
    controllers: [MovieController, ApiController]
})
export class MovieModule {}
