import { Controller, Get, Render } from '@nestjs/common';
import { MovieService } from './movie.service';

@Controller('movie')
export class MovieController {
    constructor(private movieService: MovieService) { }

    @Get()
    @Render('movies')
    async main() {

        const allMovies = await this.movieService.findAll();
        return { movies: allMovies };
    }
}