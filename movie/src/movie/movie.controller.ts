import { Controller, Get, Render } from '@nestjs/common';
import { createConnection } from 'mysql2/typings/mysql';
import Connection from 'mysql2/typings/mysql/lib/Connection';
import { MovieEntity } from './movie.entity';

@Controller('movie')
export class MovieController {

    @Get()
    @Render('movies')
    main() {

    }
}