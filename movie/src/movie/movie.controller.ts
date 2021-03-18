import { Body, Controller, Get, Param, Post, Query, Redirect, Render } from '@nestjs/common';
import { MovieService } from './movie.service';
import { MovieModel } from './movie.model';

@Controller('movie')
export class MovieController {
    constructor(private movieService: MovieService) { }

    @Get()
    @Render('movies')
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
    @Render('detalis')
    async findOne(@Param('id') id: number) {
        const theMovie = await this.movieService.findOne(id);
        return {movie: theMovie}
    }

    @Get('add')
    @Render('movie')
    async addNewMovie() {

        return {title: "Add a new movie to collection"}
    }

    @Post("add")
    @Redirect('/movie')
    async create(@Body() movie: MovieModel) {

        this.movieService.create(movie);
    }

    @Get('delete/:id')
    @Redirect('/movie')
    delete(@Param('id') id: number) {

        this.movieService.delete(id);
    }

    @Get('edit/:id')
    @Render('movie')
    async editMovie(@Param('id') id: number) {

        let title = (await this.movieService.findOne(id)).Title;
        return { title: `Edit ${title}` }
    }

    @Post('edit/:id')
    @Redirect('/movie')
    edit(@Param('id') id: number, @Body() movie: MovieModel) {

        this.movieService.update(id, movie);
    }
}   