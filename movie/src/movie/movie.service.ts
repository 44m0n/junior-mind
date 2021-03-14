import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { MovieEntity } from './movie.entity';

@Injectable()
export class MovieService {
    constructor(
        @InjectRepository(MovieEntity)
        private movieRep: Repository<MovieEntity>) { }

    findAll(): Promise<MovieEntity[]> {
        return this.movieRep.find();
    }
        
}
