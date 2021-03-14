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

    async add() {
        /*const movie = new MovieEntity();
        movie.Title = "TestMovie";
        movie.Genre = "Commedy";
        movie.ReleaseDate = new Date();
        movie.Price = 9.99;

        await this.movieRep.save(movie);
        */
        const allMovies = await this.movieRep.find();
        console.log(allMovies[0].Title);
    }
        
}
