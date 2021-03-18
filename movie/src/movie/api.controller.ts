import { Body, Controller, Delete, Get, Param, Post, Put, Query, Redirect, Render } from '@nestjs/common';
import { MovieService } from './movie.service';
import { MovieModel } from './movie.model';

@Controller('api/movies')
export class ApiController {
    constructor(private movieService: MovieService) { }

    @Get()
    async search(@Query('searchString') searchString: string) {

        if (searchString === undefined)
        {
            const allMovies = await this.movieService.findAll();
            return { movies: allMovies }
        }
        const allMovies = await this.movieService.findFilter(searchString);
        return { movies: allMovies };
    }

    @Get('detalis/:id')
    async findOne(@Param('id') id: number) {
        const theMovie = await this.movieService.findOne(id);
        return {movie: theMovie}
    }

    @Post("add")
    async create(@Body() movie: MovieModel) {

        this.movieService.create(movie);
    }

    @Delete('delete/:id')
    delete(@Param('id') id: number) {

        this.movieService.delete(id);
    }

    @Put('edit/:id')
    edit(@Param('id') id: number, @Body() movie: MovieModel) {

        this.movieService.update(id, movie);
    }
}   