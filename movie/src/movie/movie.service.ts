import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { title } from 'process';
import { DeleteResult, Repository, UpdateEvent } from 'typeorm';
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

    delete(id: number): Promise<DeleteResult> {

        return this.movieRep.delete(id);
    }

    async update(id: number, movie: MovieModel): Promise<MovieEntity> {

        let movieToUpdate = await this.movieRep.findOne(id);
        movieToUpdate.Title = movie.Title;
        movieToUpdate.ReleaseDate = movie.ReleaseDate;
        movieToUpdate.Genre = movie.Genre;
        movieToUpdate.Price = movie.Price;

        return this.movieRep.save(movieToUpdate)
    }

    findFilter(search: string): Promise<MovieEntity[]> {
        const movies = this.movieRep
            .createQueryBuilder("movie")
            .where("movie.Title = :Title", { Title: search })
            .getMany();
        return movies;
    }
}
