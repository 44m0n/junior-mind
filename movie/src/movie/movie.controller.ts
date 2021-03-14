import { Controller, Get, Render } from '@nestjs/common';
import { createConnection } from 'mysql2/typings/mysql';
import Connection from 'mysql2/typings/mysql/lib/Connection';
import { MovieEntity } from './movie.entity';
import { MovieService } from './movie.service';

@Controller('movie')
export class MovieController {
    constructor(private movieService: MovieService) { }

    @Get()
    @Render('movies')
    async main() {

        const allMovies = await this.movieService.findAll();
        console.log(allMovies.length);
    }
}