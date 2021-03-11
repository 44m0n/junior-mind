import { Controller, Get, Render } from '@nestjs/common';

@Controller('movie')
export class MovieController {

    @Get()
    @Render('movies')
    main() {
        return { text: `This is Movie Page` };
    }
}