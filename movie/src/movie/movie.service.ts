import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { title } from 'process';
import { Repository } from 'typeorm';
import { MovieEntity } from './movie.entity';
import { MovieModel } from './movie.model';

@Injectable()
export class MovieService {
    constructor(
        @InjectRepository(MovieEntity)
        private movieRep: Repository<MovieEntity>) { }

    findAll(): Promise<MovieEntity[]> {
        const movies =  this.movieRep.find();
        return movies;
    }

    findOne(id: number): Promise<MovieEntity> {
        const movie = this.movieRep.findOne(id);
        return movie;
    }

    create(movie: MovieModel): Promise<MovieEntity> {

        const movieToAdd = new MovieEntity()
        movieToAdd.Title = movie.Title;
        movieToAdd.Genre = movie.Genre;
        movieToAdd.ReleaseDate = new Date(movie.ReleaseDate);
        movieToAdd.Price = movie.Price;

        return this.movieRep.save(movieToAdd);
    }
        
}
