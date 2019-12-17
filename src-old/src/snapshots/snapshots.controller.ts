import { Controller } from '@nestjs/common';
import { ApiUseTags } from '@nestjs/swagger';
import { Crud, CrudController } from '@nestjsx/crud';
import { Snapshot } from '../models';
import { SnapshotsService } from './snapshots.service';

@Crud({
	model: {
		type: Snapshot
	},
	query: {
		join: {
			domain: {},
			registrar: {},
			nameServers: {}
		}
	}
})
@ApiUseTags('snapshots')
@Controller('snapshots')
export class SnapshotsController implements CrudController<Snapshot> {
	constructor(public service: SnapshotsService) { }
}